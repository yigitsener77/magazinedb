const toggleActivation = (id) => {
    fetch(`/home/togglecategoryactivation/${id}`, { method: "POST" })
        .then(res => res.text())
        .then(data => {
            if (data == 'True') {
                document.querySelector(`.category-item[key="${id}"] .btn-activation`).innerHTML = `<i class="fa-regular fa-square-check text-success fa-2x" title="Deactivate"></i>`
            } else {
                document.querySelector(`.category-item[key="${id}"] .btn-activation`).innerHTML = `<i class="fa-regular fa-square text-secondary fa-2x" title="Activate"></i>`
            }
        })
        .catch(err => console.error("Activation Error:", err))
}

const toggleRecycling = (id) => {
    fetch(`/home/togglecategoryrecycling/${id}`, { method: "POST" })
        .then(res => res.text())
        .then(data => {
            if (data == 'True') {
                document.querySelector(`.category-item[key="${id}"] .btn-recycling`).innerHTML = `<i class="fa-solid fa-recycle fa-2x text-info" title="Recycle"></i>`
            } else {
                document.querySelector(`.category-item[key="${id}"] .btn-recycling`).innerHTML = `<i class="fa-solid fa-trash-can fa-2x text-danger" title="Delete"></i>`
            }
        })
        .catch(err => console.error("Recycling Error:", err))
}

const editCategory = (id) => {
    const name = document.querySelector(`.category-item[key="${id}"]>td:first-child`).innerText
    document.getElementById('Name').value = name
    document.getElementById('Id').value = id
    document.getElementById('btn-form').innerText = "Update Category"
}

const resetForm = () => {
    document.getElementById('Name').value = ""
    document.getElementById('Id').value = ""
    document.getElementById('btn-form').innerText = "Create Category"
}

const category_items = document.getElementsByClassName('category-item')

Array.from(category_items).forEach(item => {
    const id = item.getAttribute('key')

    item.querySelector('.btn-activation').addEventListener('click', () => toggleActivation(id))
    item.querySelector('.btn-recycling').addEventListener('click', () => toggleRecycling(id))
    item.querySelector('.btn-edit').addEventListener('click', () => editCategory(id))
})

document.getElementById("btn-reset").addEventListener("click", resetForm)